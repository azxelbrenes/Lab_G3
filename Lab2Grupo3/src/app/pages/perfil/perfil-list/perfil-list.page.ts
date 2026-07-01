import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import {
  IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
  IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons,
  AlertController
} from '@ionic/angular/standalone';
import { addIcons } from 'ionicons';
import { addOutline, createOutline, trashOutline } from 'ionicons/icons';

import { SegPerfil } from '../../../models/seg-perfil';
import { SegPerfilService } from '../../../services/seg-perfil';

@Component({
  selector: 'app-perfil-list',
  templateUrl: './perfil-list.page.html',
  styleUrls: ['./perfil-list.page.scss'],
  standalone: true,
  imports: [
    CommonModule, RouterLink,
    IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
    IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons
  ],
})
export class PerfilListPage implements OnInit {
  private segPerfilService = inject(SegPerfilService);
  private alertCtrl = inject(AlertController);

  perfiles: SegPerfil[] = [];
  cargando = false;

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline });
  }

  ngOnInit(): void {
    this.cargar();
  }

  cargar(): void {
    this.cargando = true;
    this.segPerfilService.obtenerPerfiles().subscribe({
      next: (resp) => {
        this.perfiles = resp?.data ?? resp ?? [];
        this.cargando = false;
      },
      error: () => {
        this.cargando = false;
      }
    });
  }

  async eliminar(item: SegPerfil): Promise<void> {
    const alert = await this.alertCtrl.create({
      header: 'Confirmar',
      message: '¿Eliminar este registro?',
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.segPerfilService.eliminarPerfil(item.codigoPerfil).subscribe(() => {
              this.cargar();
            });
          }
        }
      ]
    });
    await alert.present();
  }
}
