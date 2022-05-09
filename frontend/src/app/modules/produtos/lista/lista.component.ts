import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'produtos-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaProdutosComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  async onCardClick(e: any):Promise<void>{
    alert("Clicou!!!");
  }
}
