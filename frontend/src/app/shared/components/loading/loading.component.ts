import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { LoadingService } from 'src/app/services/loading.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit, OnDestroy {
  @Input()
  enum!: string;

  constructor(public loading: LoadingService) {}

  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.loading.currentEnum = ' ';
  }
}