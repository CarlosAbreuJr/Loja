import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdutoDetalhesComponent } from './detalhes.component';

describe('DetalhesComponent', () => {
  let component: ProdutoDetalhesComponent;
  let fixture: ComponentFixture<ProdutoDetalhesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProdutoDetalhesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdutoDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
