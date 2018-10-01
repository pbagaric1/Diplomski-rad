import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { DataStorageService } from '../../shared/data-storage.service';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent implements OnInit {

  @ViewChild('closeBtn') closeBtn: ElementRef;
  users: any = [];
  userId: string;
  selectedIndex: number;

  constructor(private dataStorageService: DataStorageService) { }

  ngOnInit() {

    this.dataStorageService.getAllUsers()
      .subscribe((data: any) => {
        console.log(data)
        this.users = data;
      })
  }


  private closeModal() {
    this.closeBtn.nativeElement.click();
  //  this.closeEdit.nativeElement.click();
}

  onDelete(id: string, index: number) {
    this.userId = id;
    this.selectedIndex = index;
    console.log(this.selectedIndex)
    console.log(id);
}

  onDeleteModal() {
    this.dataStorageService.deleteUser(this.userId)
      .subscribe((response: any) => {
        console.log(response)
        window.alert(" User deleted!")
        this.users.splice(this.selectedIndex, 1);
      })

    this.closeModal();
}

}
