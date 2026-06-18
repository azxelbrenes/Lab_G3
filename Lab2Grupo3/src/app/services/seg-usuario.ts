import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class SegUsuarioService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 LISTAR USUARIOS
  obtenerUsuarios(): Observable<any> {
    return this.http.get(`${baseUrl}/Usuario/Listar`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 OBTENER USUARIO POR ID
  obtenerPorId(id: number): Observable<any> {
    return this.http.get(`${baseUrl}/Usuario/Obtener/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 CREAR USUARIO
  crearUsuario(usuario: any): Observable<any> {
    return this.http.post(`${baseUrl}/Usuario/Insertar`, usuario).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR USUARIO
  actualizarUsuario(usuario: any): Observable<any> {
    return this.http.put(`${baseUrl}/Usuario/Actualizar`, usuario).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ELIMINAR USUARIO
  eliminarUsuario(id: number): Observable<any> {
    return this.http.delete(`${baseUrl}/Usuario/Eliminar/${id}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 MANEJO DE ERRORES
  private handleError(error: any) {
    console.error('SegUsuarioService error:', error);
    return of(false);
  }
}