// Estado genérico que usan las páginas de formulario (crear/editar).
export interface FormState {
  isEdit: boolean;
  loading: boolean;
  error?: string;
}
