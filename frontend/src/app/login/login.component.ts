import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: any;
  userLogin: any = {}
  isAuthenticated: boolean = false;
  

  constructor(private formGroup: FormBuilder,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.createForm();
    
  }

  createForm() {
    this.loginForm = this.formGroup.group({
      document: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(14)]],
      password: ['', [Validators.required]]
    });
  }

  submitForm(event?: any){
    if (event){
      event.preventDefault();
      event.stopPropagation();
    }
    this.authenticate();
  }

  authenticate() {
    let user: any = {
      document: this.loginForm.get('document')?.value,
      password: this.loginForm.get('password')?.value
    }
    this.authService.authenticate(user).subscribe({
      next: data => {
        if (data){
          localStorage.setItem('user_logged', JSON.stringify(data));
          this.isAuthenticated = true;
        } else {
          console.log('Usuário Inválido');
        }
        console.log(data);
      },
      error: err => {
        console.log('Usuário Inválido');
      }
    });
  }



}


