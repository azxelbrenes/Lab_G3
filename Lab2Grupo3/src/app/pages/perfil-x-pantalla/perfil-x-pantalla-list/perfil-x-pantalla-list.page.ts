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

import { SegPerfilXpantalla } from '../../../models/seg-perfil-xpantalla';
import { SegPerfilXpantallaService } from '../../../services/seg-perfil-xpantalla';

@Component({
  selector: 'app-perfil-x-pantalla-list',
  templateUrl: './perfil-x-pantalla-list.page.html',
  styleUrls: ['./perfil-x-pantalla-list.page.scss'],
  standalone: true,
  imports: [
    CommonModule, RouterLink,
    IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
    IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons
  ],
})
export class PerfilXPantallaListPage implements OnInit {
  private segPerfilXpantallaService = inject(SegPerfilXpantallaService);
  private alertCtrl = inject(AlertController);

  perfilXPantallas: SegPerfilXpantalla[] = [];
  cargando = false;

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline });
  }

  ngOnInit(): void {
    this.cargar();
  }

  cargar(): void {
    this.cargando = true;
    this.segPerfilXpantallaService.obtenerPerfilXPantallas().subscribe({
      next: (resp) => {
        this.perfilXPantallas = resp?.data ?? resp ?? [];
        this.cargando = false;
      },
      error: () => {
        this.cargando = false;
      }
    });
  }

  async eliminar(item: SegPerfilXpantalla): Promise<void> {
    const alert = await this.alertCtrl.create({
      header: 'Confirmar',
      message: '¿Eliminar este registro?',
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.segPerfilXpantallaService.eliminarPerfilXPantalla(item.perfilXpantallaId).subscribe(() => {
              this.cargar();
            });
          }
        }
      ]
    });
    await alert.present();
  }
}
