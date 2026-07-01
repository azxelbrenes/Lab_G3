import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'home',
    loadComponent: () => import('./home/home.page').then((m) => m.HomePage),
  },
  {
    path: 'pedidos',
    loadComponent: () =>
      import('./pages/pedido/pedido-list/pedido-list.page').then((m) => m.PedidoListPage),
  },
  {
    path: 'pedidos/nuevo',
    loadComponent: () =>
      import('./pages/pedido/pedido-form/pedido-form.page').then((m) => m.PedidoFormPage),
  },
  {
    path: 'pedidos/editar/:id',
    loadComponent: () =>
      import('./pages/pedido/pedido-form/pedido-form.page').then((m) => m.PedidoFormPage),
  },
  {
    path: 'clientes',
    loadComponent: () =>
      import('./pages/cliente/cliente-list/cliente-list.page').then((m) => m.ClienteListPage),
  },
  {
    path: 'clientes/nuevo',
    loadComponent: () =>
      import('./pages/cliente/cliente-form/cliente-form.page').then((m) => m.ClienteFormPage),
  },
  {
    path: 'clientes/editar/:id',
    loadComponent: () =>
      import('./pages/cliente/cliente-form/cliente-form.page').then((m) => m.ClienteFormPage),
  },
  {
    path: 'productos',
    loadComponent: () =>
      import('./pages/producto/producto-list/producto-list.page').then((m) => m.ProductoListPage),
  },
  {
    path: 'productos/nuevo',
    loadComponent: () =>
      import('./pages/producto/producto-form/producto-form.page').then((m) => m.ProductoFormPage),
  },
  {
    path: 'productos/editar/:id',
    loadComponent: () =>
      import('./pages/producto/producto-form/producto-form.page').then((m) => m.ProductoFormPage),
  },
  {
    path: 'categorias',
    loadComponent: () =>
      import('./pages/categoria/categoria-list/categoria-list.page').then((m) => m.CategoriaListPage),
  },
  {
    path: 'categorias/nuevo',
    loadComponent: () =>
      import('./pages/categoria/categoria-form/categoria-form.page').then((m) => m.CategoriaFormPage),
  },
  {
    path: 'categorias/editar/:id',
    loadComponent: () =>
      import('./pages/categoria/categoria-form/categoria-form.page').then((m) => m.CategoriaFormPage),
  },
  {
    path: 'detalles-pedido',
    loadComponent: () =>
      import('./pages/detalle/detalle-list/detalle-list.page').then((m) => m.DetalleListPage),
  },
  {
    path: 'detalles-pedido/nuevo',
    loadComponent: () =>
      import('./pages/detalle/detalle-form/detalle-form.page').then((m) => m.DetalleFormPage),
  },
  {
    path: 'detalles-pedido/editar/:id',
    loadComponent: () =>
      import('./pages/detalle/detalle-form/detalle-form.page').then((m) => m.DetalleFormPage),
  },
  {
    path: 'usuarios',
    loadComponent: () =>
      import('./pages/usuario/usuario-list/usuario-list.page').then((m) => m.UsuarioListPage),
  },
  {
    path: 'usuarios/nuevo',
    loadComponent: () =>
      import('./pages/usuario/usuario-form/usuario-form.page').then((m) => m.UsuarioFormPage),
  },
  {
    path: 'usuarios/editar/:id',
    loadComponent: () =>
      import('./pages/usuario/usuario-form/usuario-form.page').then((m) => m.UsuarioFormPage),
  },
  {
    path: 'perfiles',
    loadComponent: () =>
      import('./pages/perfil/perfil-list/perfil-list.page').then((m) => m.PerfilListPage),
  },
  {
    path: 'perfiles/nuevo',
    loadComponent: () =>
      import('./pages/perfil/perfil-form/perfil-form.page').then((m) => m.PerfilFormPage),
  },
  {
    path: 'perfiles/editar/:id',
    loadComponent: () =>
      import('./pages/perfil/perfil-form/perfil-form.page').then((m) => m.PerfilFormPage),
  },
  {
    path: 'pantallas',
    loadComponent: () =>
      import('./pages/pantalla/pantalla-list/pantalla-list.page').then((m) => m.PantallaListPage),
  },
  {
    path: 'pantallas/nuevo',
    loadComponent: () =>
      import('./pages/pantalla/pantalla-form/pantalla-form.page').then((m) => m.PantallaFormPage),
  },
  {
    path: 'pantallas/editar/:id',
    loadComponent: () =>
      import('./pages/pantalla/pantalla-form/pantalla-form.page').then((m) => m.PantallaFormPage),
  },
  {
    path: 'perfil-pantallas',
    loadComponent: () =>
      import('./pages/perfil-x-pantalla/perfil-x-pantalla-list/perfil-x-pantalla-list.page').then((m) => m.PerfilXPantallaListPage),
  },
  {
    path: 'perfil-pantallas/nuevo',
    loadComponent: () =>
      import('./pages/perfil-x-pantalla/perfil-x-pantalla-form/perfil-x-pantalla-form.page').then((m) => m.PerfilXPantallaFormPage),
  },
  {
    path: 'perfil-pantallas/editar/:id',
    loadComponent: () =>
      import('./pages/perfil-x-pantalla/perfil-x-pantalla-form/perfil-x-pantalla-form.page').then((m) => m.PerfilXPantallaFormPage),
  },
  {
    path: 'tipos-cedula',
    loadComponent: () =>
      import('./pages/tipo-cedula/tipo-cedula-list/tipo-cedula-list.page').then((m) => m.TipoCedulaListPage),
  },
  {
    path: 'tipos-cedula/nuevo',
    loadComponent: () =>
      import('./pages/tipo-cedula/tipo-cedula-form/tipo-cedula-form.page').then((m) => m.TipoCedulaFormPage),
  },
  {
    path: 'tipos-cedula/editar/:id',
    loadComponent: () =>
      import('./pages/tipo-cedula/tipo-cedula-form/tipo-cedula-form.page').then((m) => m.TipoCedulaFormPage),
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];
