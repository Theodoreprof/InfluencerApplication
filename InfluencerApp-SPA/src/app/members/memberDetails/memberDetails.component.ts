import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-memberDetails',
  templateUrl: './memberDetails.component.html',
  styleUrls: ['./memberDetails.component.css']
})
export class MemberDetailsComponent implements OnInit {
  user: User;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private userService: UserService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['user'];
    });
    this.galleryOptions = [
        {
          width: '500px',
          height: '500px',
          imagePercent: 100,
          thumbnailsColumns: 4,
          imageAnimation: NgxGalleryAnimation.Slide,
          preview: false
        }
    ];
    this.galleryImages = this.getImages();
    this.CheckLinks();
  }

  getImages(){
    const imageUrls = [];
    for (let i = 0; i< this.user.photos.length; i++) {
      imageUrls.push({
        small: this.user.photos[i].url,
        medium: this.user.photos[i].url,
        big: this.user.photos[i].url
      });
    }
    return imageUrls;
  }

  CheckLinks() {
    if ((this.user.youtubeChannelLink && this.user.twitterProfileLInk
      && this.user.instagramProfileLink && this.user.facebookProfileLink) === null) {
      return true;
    }
  }

}
