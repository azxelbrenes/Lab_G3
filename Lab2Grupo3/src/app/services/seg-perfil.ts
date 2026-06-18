import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class SegPerfilService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 OBTENER PERFIL POR ID DE USUARIO
  obtenerPerfil(usuarioId: number): Observable<any> {
    return this.http.get(`${baseUrl}/Perfil/Obtener/${usuarioId}`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 ACTUALIZAR PERFIL
  actualizarPerfil(perfil: any): Observable<any> {
    return this.http.put(`${baseUrl}/Perfil/Actualizar`, perfil).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 CREAR PERFIL
  crearPerfil(perfil: any): Observable<any> {
    return this.http.post(`${baseUrl}/Perfil/Insertar`, perfil).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 MANEJO DE ERRORES
  private handleError(error: any) {
    console.error('SegPerfilService error:', error);
    return of(false);
  }
}