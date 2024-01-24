import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../../helpers/validateform';
import { AuthService } from '../../services/auth.service';
import { Route, Router } from '@angular/router';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

	type: string = "senha";
	isText: boolean = false;
	eyeIcon: string = "fa-eye-slash";
	loginForm!: FormGroup;
	constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }
	ngOnInit(): void {
		this.loginForm = this.fb.group({
			email: ['', Validators.required],
			senha: ['', Validators.required]
		})
	}


	hideShowPass() {
		this.isText = !this.isText;
		this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash"
		this.isText ? this.type = "text" : this.type = "password"
	}

	onLogin() {
		if (this.loginForm.valid) {
			this.auth.login(this.loginForm.value)
			.subscribe({
				next:(res) =>{
					alert(res.message);
					this.loginForm.reset();
					this.router.navigate(['home'])
				},
				error:(err) =>{
					alert(err?.error.message)
				}
			})
		} else {
			console.log("Formulario invalido")
			ValidateForm.validateAllFormFileds(this.loginForm);
			alert("Seu formulario é inválido")
		}
	}
}
