import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MembersListsComponent } from './MembersLists/MembersLists.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';


export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'members', component: MembersListsComponent, canActivate: [AuthGuard] },
    { path: 'messages', component: MessagesComponent, canActivate: [AuthGuard] },
    { path: 'lists', component: ListsComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];

