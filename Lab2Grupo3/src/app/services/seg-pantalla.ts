import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = environment.baseUrl;

@Injectable({
  providedIn: 'root'
})
export class SegPantallaService {

  private http = inject(HttpClient);

  constructor() {}

  // 🔹 EJEMPLO 1: generar acciones
  generarAcciones(numFactura: number, correo: string, telefono: string): Observable<any> {
    return this.http.post(`${baseUrl}/Tombola/lfGenerarAcciones`, {
      numFactura,
      correo,
      telefono
    }).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔹 EJEMPLO 2: obtener ganadores
  obtenerGanadores(): Observable<any> {
    return this.http.get(`${baseUrl}/Tombola/lfGenerarGanador`).pipe(
      map(resp => resp),
      catchError(error => this.handleError(error))
    );
  }

  // 🔴 ERROR HANDLER
  private handleError(error: any) {
    console.error('SegPantallaService error:', error);
    return of(false);
  }
}