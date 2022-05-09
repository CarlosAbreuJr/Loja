import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
// import { MatRipple } from '@angular/material/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListaProdutosComponent } from './modules/produtos/lista/lista.component';
import { ProdutoDetalhesComponent } from './modules/produtos/detalhes/detalhes.component';

import { PagamentoComponent } from './modules/carrinho/pagamento/pagamento.component';
import { PedidoComponent } from './modules/carrinho/pedido/pedido.component';
import { ItemComponent } from './modules/carrinho/item/item.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { LoadingComponent } from './shared/components/loading/loading.component';
import { ModalComponent } from './shared/components/modal/modal.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { SideBarComponent } from './shared/components/side-bar/side-bar.component';
import { LoginComponent } from './shared/components/login/login.component';
import { HomeComponent } from './modules/home/home.component';
import { ProductComponent } from './shared/components/product/product.component';
import { AuthenticationComponent } from './modules/authentication/authentication.component';
import { ProdutoCadastroComponent } from './modules/produtos/cadastro/cadastro.component';
import { UsuarioCadastroComponent } from './modules/usuario/cadastro/cadastro.component';
import { FormsModule } from '@angular/forms';
import { SpinnerComponent } from './shared/components/spinner/spinner.component';
import { AuthenticationService } from './services/authentication/authentication.service';
import { LoginGuard } from './guard/login.guard';
import { AuthGuard } from './guard/auth.guard';
import { httpInterceptorProviders } from './services/http-interceptors';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ListaProdutosComponent,
    ProdutoDetalhesComponent,
    PedidoComponent,
    PagamentoComponent,
    ItemComponent,
    HeaderComponent,
    LoadingComponent,
    ModalComponent,
    FooterComponent,
    SideBarComponent,
    LoginComponent,
    HomeComponent,
    ProductComponent,
    AuthenticationComponent,
    ProdutoCadastroComponent,
    UsuarioCadastroComponent,
    SpinnerComponent
  ],
  imports: [
    MatMenuModule,
    MatCardModule,
    // MatRipple,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    
  ],
  providers: [
    AuthenticationService,
    LoginGuard,
    httpInterceptorProviders,
    AuthGuard,],
  bootstrap: [AppComponent]
})
export class AppModule { }
