import { Component, OnInit } from '@angular/core';
import { UserService } from './../services/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  users: any;
  userLogged: any = {};
  isAuthenticated: boolean = false;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUserData();
    if (this.isAuthenticated) {
      this.get();
    }      
  }

  get() {
    this.userService.get().subscribe({
      next: data => {
        if (data) {
          this.users = data;
        }  
      },
      error: err => {
        console.log('error');
        alert('erro interno do sistema');
      }
    });
  }

  getUserData(){     
    this.userLogged = JSON.parse(localStorage.getItem('user_logged') || '{}');
    this.isAuthenticated = this.userLogged.name != undefined;
    console.log(this.isAuthenticated);
  }  

}
