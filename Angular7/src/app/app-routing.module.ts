import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';


// The below is how we set routes for angular projects e.g: /user/registration
const routes: Routes = [
  { path:'', redirectTo:'/user/registration', pathMatch:'full'},

  { path:'user', component: UserComponent, 
  children: [
    {path: 'registration', component: RegistrationComponent },
    {path: 'login', component: LoginComponent }

    ] 
  }
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]

})
export class AppRoutingModule { }
