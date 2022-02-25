import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class PresenceService {
  hubUrl = environment.hubUrl;
  private hubConnection: HubConnection;

  constructor(private alertify: ToastrService) { }

  createHubConnection(user: User){
    this.hubConnection = new HubConnectionBuilder()
    .withUrl(this.hubUrl + 'presence', {
      accessTokenFactory: () => user.Token
    })
    .withAutomaticReconnect()
    .build()

    this.hubConnection.start().catch(error => console.log(error));

    this.hubConnection.on('UserIsOnline', username => {
      this.alertify.info(username + ' has connected')
    });
    this.hubConnection.on('UserIsOffline', username => {
      this.alertify.warning(username + ' has disconnected')
    });
  }
  stopHubConnection(){
    this.hubConnection.stop().catch(error => console.log(error));
  }
}
