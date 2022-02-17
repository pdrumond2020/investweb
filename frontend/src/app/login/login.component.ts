import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


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
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.createForm();
    
  }

  createForm() {
    this.loginForm = this.formGroup.group({
      document: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(14)]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  submitForm(event?: any){
    if (event){
      event.preventDefault();
      event.stopPropagation();
    }
    
    if (this.loginForm.valid) {
      this.authenticate();
    }
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
          this.toastr.success('Usuário autenticado!');
          this.router.navigate(['users']);
        } else {
          this.toastr.error('Usuário Inválido');
        }
      },
      error: err => {
        this.toastr.error('Usuário Inválido');
      }
    });
  }



}


