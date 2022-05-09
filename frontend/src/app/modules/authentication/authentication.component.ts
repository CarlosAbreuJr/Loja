import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { LoadingService } from 'src/app/services/loading.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss']
})
export class AuthenticationComponent implements OnInit {
  login: LoginModel = new LoginModel();
  constructor(public route: Router,
    private authService: AuthenticationService,
    public loading: LoadingService,
    // private modalService: ModalService,
    // private ngbModal: NgbModal,
    ) { }

  ngOnInit(): void {
  }
  
  async onLogin(form: NgForm): Promise<void> {
    this.loading.currentEnum = 'Efetuando login, aguarde...';
    this.loading.active = true;

    await this.authService.getAuthorization(this.login)
    .then(x => {
      console.log(x);
      if(x.userStatus != 0){

      }
      if(x.userStatus == 0){
        this.authService.setToken(x.token);
      }
      
      //Ir buscar o perfil do usuario.
      this.loading.active = false;
      this.route.navigate(['produtos']);
    })
    .catch((e: HttpErrorResponse) => {
      this.loading.active = false;
      console.log(e.message);
      console.log(e);
    });
    
  }
}

export class LoginModel{
  email!: string;
  password!: string;
}

// export class LoginComponent implements OnInit {
  
//   loginRequest: LoginRequest;

//   constructor(
//     private router: Router,
//     private activeRpute: ActivatedRoute,
//     public service: AuthenticationService,
//     public modalService: ModalService,
//     public loading: LoadingService
//   ) { }

//   ngOnInit(): void {
//   }

//   tabValidation(): void {
//     this.onCompletePlate();
//   }

//   onValidation(event: any): void {
//     if (event === undefined || event === null || event.key === 'Tab' || event.key === 'Meta') {
//       return;
//     }
//     if (Object.keys(this.motorista.userdocument).length >= 1
//       && !cpf.isValid(this.motorista.userdocument)) {
//       this.validDocumnet = false;
//     } else {
//       this.validDocumnet = true;
//     }
//   }

//   onCompletePlate(): void {
//     if (this.motorista?.licenseplate === undefined) {
//       return;
//     }
//     if (Object.keys(this.motorista.licenseplate).length >= 1 && Object.keys(this.motorista.licenseplate).length < 7) {
//       this.validPlate = false;
//     } else {
//       this.validPlate = true;
//     }
//   }

//   onPwd(): void {
//     if (this.pwdShow) {
//       this.pwdShow = false;
//       this.pwdType = 'password';
//       this.icon = '/assets/icons/eye_on_icon.svg';
//     } else {
//       this.pwdShow = true;
//       this.pwdType = 'text';
//       this.icon = '/assets/icons/eye_off_icon.svg';
//     }
//   }

//   async onLoginMotorista(form: NgForm): Promise<void> {
//     this.loading.active = true;
//     this.loading.currentEnum = 'Validando informações, aguarde...';
//     this.service.loginRequest = new LoginRequest();
//     this.service.loginRequest.username = this.motorista.userdocument;
//     this.service.loginRequest.password = this.motorista.userpassword;
//     this.service.loginRequest.plate = this.motorista.licenseplate;

//     await this.service.login(this.service.loginRequest)
//       .then(async res => {
//         this.loading.active = false;
//         form.reset();
//         this.service.res = res.code;

//         let oldRoute = '';
//         if (res.code === '0') {
//           this.activeRpute.queryParams.subscribe(params => oldRoute = params[`return`] || '/');
//         }
//         if (oldRoute === '' || oldRoute === '/') {
//           if (res.code === '0') {
//             oldRoute = 'operation';
//           }
//           else if (res.code === '2') {
//             oldRoute = 'new-password';
//           }
//           else if (res.code === '3') {
//             this.modalService.unregisterPlate(ModalComponent);
//           } else if (res.code === '4') {
//             this.modalService.userExpiredPassword(ModalComponent);
//           }
//         }
//         this.router.navigateByUrl(oldRoute);
//       }
//       )
//       .catch(
//         error => {
//           this.loading.active = false;
//           form.reset();
//           if (error.status === 400) {
//             this.modalService.userPasswordInvalid(ModalComponent);
//           }
//           else {
//             this.modalService.erroDefault(ModalComponent);
//           }
//         });
//   }