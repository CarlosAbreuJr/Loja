import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { ModalService } from 'src/app/services/modal/modal.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements  OnInit, OnDestroy {

  @Input() erroEnum: string | undefined;
  @Input() descritionEnum: string | undefined;
  @Input() buttoMenssage: string | undefined;
  @Input() imageModal: any;
  @Input() imgUrl: string | undefined;

  constructor(
    public activeModal: NgbActiveModal,
    public service: ModalService,
    public router: Router,
    public authService: AuthenticationService,
  ) { }
  
  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.service.basicCloseModal = false;
    this.service.basicLogOutModal = false;
  }
  
  onCancel(): void {
    this.activeModal.close(true);
    this.router.navigate(['/produtos']);
  }

  onCloseModal(): void {
    this.activeModal.close(true);
  }

  onLogOutModal(): void {
    this.onCloseModal();
    this.authService.logout();
  }

}
