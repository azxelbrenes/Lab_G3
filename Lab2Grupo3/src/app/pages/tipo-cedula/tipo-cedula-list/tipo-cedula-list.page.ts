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

import { TipoCedula } from '../../../models/tipo-cedula';
import { TipoCedulaService } from '../../../services/tipo-cedula';

@Component({
  selector: 'app-tipo-cedula-list',
  templateUrl: './tipo-cedula-list.page.html',
  styleUrls: ['./tipo-cedula-list.page.scss'],
  standalone: true,
  imports: [
    CommonModule, RouterLink,
    IonHeader, IonToolbar, IonTitle, IonContent, IonList, IonItem,
    IonLabel, IonButton, IonIcon, IonFab, IonFabButton, IonButtons
  ],
})
export class TipoCedulaListPage implements OnInit {
  private tipoCedulaService = inject(TipoCedulaService);
  private alertCtrl = inject(AlertController);

  tiposCedula: TipoCedula[] = [];
  cargando = false;

  constructor() {
    addIcons({ addOutline, createOutline, trashOutline });
  }

  ngOnInit(): void {
    this.cargar();
  }

  cargar(): void {
    this.cargando = true;
    this.tipoCedulaService.obtenerTiposCedula().subscribe({
      next: (resp) => {
        this.tiposCedula = resp?.data ?? resp ?? [];
        this.cargando = false;
      },
      error: () => {
        this.cargando = false;
      }
    });
  }

  async eliminar(item: TipoCedula): Promise<void> {
    const alert = await this.alertCtrl.create({
      header: 'Confirmar',
      message: '¿Eliminar este registro?',
      buttons: [
        { text: 'Cancelar', role: 'cancel' },
        {
          text: 'Eliminar',
          role: 'destructive',
          handler: () => {
            this.tipoCedulaService.eliminarTipoCedula(item.tipoCedula1).subscribe(() => {
              this.cargar();
            });
          }
        }
      ]
    });
    await alert.present();
  }
}
