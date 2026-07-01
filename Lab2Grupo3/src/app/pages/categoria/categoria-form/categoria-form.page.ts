import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
  IonInput, IonToggle, IonButton, IonButtons, IonBackButton, ToastController
} from '@ionic/angular/standalone';

import { CategoriumService } from '../../../services/categorium';

@Component({
  selector: 'app-categoria-form',
  templateUrl: './categoria-form.page.html',
  styleUrls: ['./categoria-form.page.scss'],
  standalone: true,
  imports: [
    CommonModule, ReactiveFormsModule,
    IonHeader, IonToolbar, IonTitle, IonContent, IonItem, IonLabel,
    IonInput, IonToggle, IonButton, IonButtons, IonBackButton
  ],
})
export class CategoriaFormPage implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private categoriumService = inject(CategoriumService);
  private toastCtrl = inject(ToastController);

  recordId: number | null = null;
  isEdit = false;
  guardando = false;

  form = this.fb.group({
    nombreCategoria: ['', [Validators.required]],
    activo: [false, []],
  });

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.recordId = Number(idParam);
      this.isEdit = true;
      this.form.get('categoriaId')?.disable();
      this.cargar(this.recordId);
    }
  }

  cargar(id: number): void {
    this.categoriumService.obtenerPorId(id).subscribe({
      next: (resp) => {
        const p = resp?.data ?? resp;
        if (p) {
          this.form.patchValue({
          nombreCategoria: p.nombreCategoria,
          activo: p.activo,
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
      ? this.categoriumService.actualizarCategoria(payload)
      : this.categoriumService.insertarCategoria(payload);

    request$.subscribe({
      next: async () => {
        this.guardando = false;
        const toast = await this.toastCtrl.create({
          message: this.isEdit ? 'Registro actualizado' : 'Registro creado',
          duration: 2000,
          color: 'success'
        });
        await toast.present();
        this.router.navigateByUrl('/categorias');
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
