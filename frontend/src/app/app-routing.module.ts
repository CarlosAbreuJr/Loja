import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { RouteGuard } from './guard/route.guard';
import { AuthenticationComponent } from './modules/authentication/authentication.component';
import { HomeComponent } from './modules/home/home.component';
import { ProdutoCadastroComponent } from './modules/produtos/cadastro/cadastro.component';
import { ProdutoDetalhesComponent } from './modules/produtos/detalhes/detalhes.component';
import { ListaProdutosComponent } from './modules/produtos/lista/lista.component';
import { UsuarioCadastroComponent } from './modules/usuario/cadastro/cadastro.component';
import { LoginComponent } from './shared/components/login/login.component';

const routes: Routes = [
  // {path:'**', redirectTo:'invalid-url'},
  // {path:'', redirectTo: 'home', pathMatch:'full'},
  // {path: 'home', component:HomeComponent},
  // {path: 'produtos', component:ListaProdutosComponent},
  // {path: 'produtos/cadastro', component:ProdutoCadastroComponent},
  // {path: 'produtos/detalhes', component:ProdutoDetalhesComponent},
  // {path: 'carrinho', component: LoginComponent, canActivate: [RouteGuard] },
  // {path: 'login', component: AuthenticationComponent, canActivate: [RouteGuard] },
  {path:'**', redirectTo:'invalid-url'},
  {
    path:'', component:HomeComponent, 
    children: [
      {path: 'produtos', component:ListaProdutosComponent},
      {path: 'produtos/cadastro', component:ProdutoCadastroComponent},
      {path: 'produtos/detalhes', component:ProdutoDetalhesComponent},
      {path: 'carrinho', component: LoginComponent},// canActivate: [RouteGuard] },
      {path: 'login', component: AuthenticationComponent},// canActivate: [RouteGuard] },
      {path: 'usuario/cadastro', component: UsuarioCadastroComponent},// canActivate: [RouteGuard] },
      
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// { path: '**', redirectTo: 'invalid-url' },
// {
//   path: '', component: LoginViewComponent,
//   children: [
//     { path: '', redirectTo: 'login', pathMatch: 'full' },
//     { path: 'login', component: LoginComponent },
//     { path: 'reset-password', component: ResetPasswordComponent },
//     { path: 'new-password', component: NewPasswordComponent, canActivate: [LoginGuard] }
//   ]
// },
// {
//   path: 'operation', component: OperationViewComponent, canActivate: [AuthGuard]
//   , children: [
//     { path: 'select', component: SelectOperationComponent, canActivate: [RouteAuthGuard] },
//     { path: 'charge', component: ChargeComponent, canActivate: [RouteAuthGuard] },
//     { path: 'charge/sealsenvelopescomp', component: SealsAndEnvelopesComponent, canActivate: [RouteAuthGuard] },
//     { path: 'charge/sealsenvelopesinput', component: InputSealsEnvelopesComponent, canActivate: [RouteAuthGuard] },
//     { path: 'charge/sealsEnvelopesconfirm', component: ConfirmSealsEnvelopesComponent, canActivate: [RouteAuthGuard] },
//     { path: 'charge/sealsenvelopesqueue', component: ChargeLineComponent, canActivate: [RouteAuthGuard] },
//     { path: 'charge/docsdisplay', component: DocumentsComponent, canActivate: [RouteAuthGuard] },
//     { path: 'charge/docsdownload', component: DownloadComponent, canActivate: [RouteAuthGuard] },
//     { path: 'uncharge', component: UnchargeComponent, canActivate: [RouteAuthGuard] },
//     { path: 'uncharge/register', component: RegisterUnchargeComponent, canActivate: [RouteAuthGuard] },
//     { path: 'uncharge/registerConfirm', component: ConfirmUnchargeDataComponent, canActivate: [RouteAuthGuard] },
//     { path: 'uncharge/print', component: PrintExitPassComponent, canActivate: [RouteAuthGuard] },
//     { path: '', redirectTo: 'select', pathMatch: 'full' },
//   ],
// },