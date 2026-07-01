import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
  IonInput, IonToggle, IonButton, IonButtons, IonBackButton, ToastController
} from '@ionic/angular/standalone';

import { SegPerfilXpantallaService } from '../../../services/seg-perfil-xpantalla';

@Component({
  selector: 'app-perfil-x-pantalla-form',
  templateUrl: './perfil-x-pantalla-form.page.html',
  styleUrls: ['./perfil-x-pantalla-form.page.scss'],
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule,
    IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
    IonInput, IonToggle, IonButton, IonButtons, IonBackButton
  ],
})
export class PerfilXPantallaFormPage implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private segPerfilXpantallaService = inject(SegPerfilXpantallaService);
  private toastCtrl = inject(ToastController);

  recordId: number | null = null;
  isEdit = false;
  guardando = false;

  form = this.fb.group({
    codigoPerfil: [null as number | null, [Validators.required, Validators.min(0)]],
    codigoPantalla: [null as number | null, [Validators.required, Validators.min(0)]],
  });

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.recordId = Number(idParam);
      this.isEdit = true;
      this.form.get('perfilXpantallaId')?.disable();
      this.cargar(this.recordId);
    }
  }

  cargar(id: number): void {
    this.segPerfilXpantallaService.obtenerPorId(id).subscribe({
      next: (resp) => {
        const p = resp?.data ?? resp;
        if (p) {
          this.form.patchValue({
          codigoPerfil: p.codigoPerfil,
          codigoPantalla: p.codigoPantalla,
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
      ? this.segPerfilXpantallaService.actualizarPerfilXPantalla(payload)
      : this.segPerfilXpantallaService.insertarPerfilXPantalla(payload);

    request$.subscribe({
      next: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: this.isEdit ? 'Registro actualizado' : 'Registro creado',
          duration: 2000,
          color: 'success'
        });
        await toast.present();
        this.router.navigateByUrl('/perfil-pantallas');
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
