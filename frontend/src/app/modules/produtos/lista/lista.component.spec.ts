import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaProdutosComponent } from './lista.component';

describe('ListaComponent', () => {
  let component: ListaProdutosComponent;
  let fixture: ComponentFixture<ListaProdutosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaProdutosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaProdutosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
