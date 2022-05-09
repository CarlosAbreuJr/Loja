import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { LoadingService } from '../loading.service';
import { environment } from 'src/environments/environment';
import { AccessResponse, TokenResponse } from './models/AccessResponse';
import { LoginModel } from 'src/app/modules/authentication/authentication.component';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private LocalStorageToken = 'access-information';
  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    // private ngbModal: NgbModal,
    // public modalService: ModalService,
    public loadService: LoadingService
  ) { }

  private generateBasicToken(): string {
    return btoa(`${environment.ClientId}:${environment.ClientSecret}`);
  }

  async getAuthorization(req: LoginModel): Promise<AccessResponse> {
    const basicToken = this.generateBasicToken();
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Basic ${basicToken}`,
    });

    return await this.http
      .post<AccessResponse>(
        `${environment.baseUrl}/v2/authentication/Login`,
        {
          email: req.email,
          password: req.password
          // grant_type: 'client_credentials',
        },
        {
          headers: headers,
        }
      )
      .toPromise()
      .then((res) => {
        // this.setToken(res);
        return res;
      });
  }
  
  setToken(resToken: TokenResponse): void {
    localStorage.setItem(
      this.LocalStorageToken,
      JSON.stringify(resToken)
    );
  }

  isUserLogged(): boolean {
    const tokenInformation = JSON.parse(localStorage.getItem(this.LocalStorageToken)!) as TokenResponse;
    if (tokenInformation === null) {
      return false;
    }

    const validExpiration =
      new Date() <= new Date(tokenInformation.expiration);
    return validExpiration;
  }

  getUserInformation(): AccessResponse {
    return JSON.parse(localStorage.getItem(this.LocalStorageToken)!) as AccessResponse;
  }

  logout(): void {
    //Revogar Token ??
    this.clearLocalStore();
    this.router.navigateByUrl('/produtos');
  }

  clearLocalStore(): void {
    localStorage.removeItem(this.LocalStorageToken);
  }
}
