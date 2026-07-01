import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
  IonInput, IonToggle, IonButton, IonButtons, IonBackButton, ToastController
} from '@ionic/angular/standalone';

import { SegUsuarioService } from '../../../services/seg-usuario';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.page.html',
  styleUrls: ['./usuario-form.page.scss'],
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule,
    IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
    IonInput, IonToggle, IonButton, IonButtons, IonBackButton
  ],
})
export class UsuarioFormPage implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private segUsuarioService = inject(SegUsuarioService);
  private toastCtrl = inject(ToastController);

  recordId: string | null = null;
  isEdit = false;
  guardando = false;

  form = this.fb.group({
    usuario: [{value: '', disabled: false}, [Validators.required]],
    cedulaUsuario: ['', [Validators.required]],
    tipoCedulaId: [null as number | null, [Validators.required, Validators.min(0)]],
    nombre: ['', [Validators.required]],
    apellidos: ['', [Validators.required]],
    direccion: ['', []],
    codigoPerfil: [null as number | null, [Validators.required, Validators.min(0)]],
    email: ['', []],
    telefono: ['', []],
    estado: [null as number | null, [Validators.required, Validators.min(0)]],
  });

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.recordId = idParam;
      this.isEdit = true;
      this.form.get('usuario')?.disable();
      this.cargar(this.recordId);
    }
  }

  cargar(id: string): void {
    this.segUsuarioService.obtenerPorId(id).subscribe({
      next: (resp) => {
        const p = resp?.data ?? resp;
        if (p) {
          this.form.patchValue({
          usuario: p.usuario,
          cedulaUsuario: p.cedulaUsuario,
          tipoCedulaId: p.tipoCedulaId,
          nombre: p.nombre,
          apellidos: p.apellidos,
          direccion: p.direccion,
          codigoPerfil: p.codigoPerfil,
          email: p.email,
          telefono: p.telefono,
          estado: p.estado,
          });
        }
      }
    });
  }

  async guardar(): Promise<void> {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.guardando = true;
    const payload = { ...this.form.getRawValue() };

    const request$ = this.isEdit
      ? this.segUsuarioService.actualizarUsuario(payload)
      : this.segUsuarioService.crearUsuario(payload);

    request$.subscribe({
      next: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: this.isEdit ? 'Registro actualizado' : 'Registro creado',
          duration: 2000,
          color: 'success'
        });
        await toast.present();
        this.router.navigateByUrl('/usuarios');
      },
      error: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: 'Ocurrió un error al guardar',
          duration: 2000,
          color: 'danger'
        });
        await toast.present();
      }
    });
  }
}
