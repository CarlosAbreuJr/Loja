import { Injectable, Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  public basicCloseModal: boolean = false;
  public basicLogOutModal: boolean = false;
  constructor(private ngbModal: NgbModal) { }

  erroDefaultCustom(component: any, msg: any): void {
    this.basicLogOutModal = true;
    const modalRef = this.ngbModal.open(component, {
      backdrop: 'static',
      keyboard: false,
    });
    // modalRef.componentInstance.imgUrl = ImgUrl.meh;
    // modalRef.componentInstance.erroEnum = ErrorEnum.genericError;
    // modalRef.componentInstance.descritionEnum = `${msg}<br /><br /> ${DescritionEnum.invalid}`;
    // modalRef.componentInstance.buttoMenssage = ButtoMenssage.OK;
    modalRef.componentInstance.descritionEnum = `${msg}<br />`;
    modalRef.componentInstance.buttoMenssage = 'Fechar';
  }


}
