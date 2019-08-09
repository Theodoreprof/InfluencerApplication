using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using InfluencerApp.API.Data;
using InfluencerApp.API.Dtos;
using InfluencerApp.API.Helpers;
using InfluencerApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfluencerApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]

    public class MessagesController : ControllerBase
    {
        private readonly ICollabRepository _repo;
        private readonly IMapper _mapper;
        public MessagesController(ICollabRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet("{id}", Name="GetMessage")]
        public async Task<IActionResult> GetMessage(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var messageFromRepo = await _repo.GetMessage(id);

            if (messageFromRepo == null) {
                return NotFound();
            }

            return Ok(messageFromRepo);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessagesForUser(int userId, 
            [FromQuery]MessageParams messageParams)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            messageParams.UserId = userId;
            
            var messagesFromRepo = await _repo.GetMessagesForUser(messageParams);

            var messages = _mapper.Map<IEnumerable<MessageToReturnDto>>(messagesFromRepo);

            Response.AddPagination(messagesFromRepo.CurrentPage, messagesFromRepo.PageSize, 
                messagesFromRepo.TotalCount, messagesFromRepo.TotalPages);
            
            return Ok(messages);
        }

        [HttpGet("thread/{recipientId}")]
        public async Task<IActionResult> GetMessageThread(int userId, int recipientId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var messageFromRepo = await _repo.GetMessageThread(userId, recipientId);

            var messageThread = _mapper.Map<IEnumerable<MessageToReturnDto>>(messageFromRepo);

            return Ok(messageThread);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int userId, MessageForCreationDto messageForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            messageForCreationDto.SenderId = userId;

            var recipient = await _repo.GetUser(messageForCreationDto.RecipientId);

            if (recipient == null)
                return BadRequest("Could not find user");

            var message = _mapper.Map<Message>(messageForCreationDto);

            _repo.Add(message);

            var messageToReturn = _mapper.Map<MessageForCreationDto>(message);

            if (await _repo.SaveAll()) {
                return CreatedAtRoute("GetMessage", new {id = message.Id}, messageToReturn);
            }

            throw new Exception("Creating the message faild on save");
        }




    }
}