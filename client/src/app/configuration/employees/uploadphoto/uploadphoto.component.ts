import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-uploadphoto',
  templateUrl: './uploadphoto.component.html',
  styleUrls: ['./uploadphoto.component.css']
})
export class UploadphotoComponent implements OnInit {
  @Input() targetUrl: string;
  @Output() getMemberPhotoChange = new EventEmitter<string>();

  uploader: FileUploader;
  constructor(private alertify: ToastrService) {

  }
  ngOnInit() {
      this.initializeUploader();
  }

  initializeUploader() {
     this.uploader = new FileUploader({
          url: this.targetUrl,
          authToken: 'Bearer ' + localStorage.getItem('token'),
          isHTML5: true,
          allowedFileType: ['image'],
          removeAfterUpload: true,
          autoUpload: true,
          maxFileSize: 10 * 1024 * 1024
      });

      this.uploader.onAfterAddingFile = file => {
          file.withCredentials = false;
          console.log(file);
          this.alertify.success('Photo uploaded ...');
      };

      this.uploader.onSuccessItem = (item, response, status, headers) => {
          if (response) {
              const res: any = JSON.parse(response);
              this.getMemberPhotoChange.emit(res.image);
          }
      };
  }
}

