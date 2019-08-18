import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
 userDetails:any;

  constructor(private router:Router, private service:UserService) { }

  ngOnInit() {
    // We are interecepting the http request and response and checking if the details exist
    this.service.getUserDetails().subscribe(
      res =>{
        this.userDetails = res;
      },
      err =>{
        if(err.status == 401) {
          localStorage.removeItem('token');
          this.router.navigateByUrl('/user/login');
        }
      }
    )
    document.querySelector('body').classList.add('login');
  }


  onLogout() {
    localStorage.removeItem('token');
    document.querySelector('body').classList.remove('login');
    this.router.navigateByUrl('/user/login');

  }



}
