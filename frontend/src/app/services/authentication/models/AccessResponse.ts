export class AccessResponse {
    public token!: TokenResponse;
    public userStatus!: number;
    public message!: string;
    }
export class TokenResponse{
    public accessToken:string ='';
    public refreshToken:string='';
    public expiration:number=0;
}