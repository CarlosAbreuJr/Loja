export class ProductModel {
  nome: string = '';
  descricao: string = '';
  detalhes: string | undefined;
  estrelas: string | undefined;
  foto: string[] = [];
  precoAntigo: number = 0;
  precoNovo: number | undefined;
  tamanho: string | undefined;
  cor: string | undefined;
  marcarId: number = 0;
  fabricanteId: number = 0;
}
