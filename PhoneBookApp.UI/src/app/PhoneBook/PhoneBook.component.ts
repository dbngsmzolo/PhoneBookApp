import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {PhoneBookService} from '../PhoneBook/services/PhoneBook.service';

@Component({
  selector: 'app-PhoneBook',
  templateUrl: './PhoneBook.component.html',
  styleUrls: ['./PhoneBook.component.css']
})
export class PhoneBookComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private phoneBookService: PhoneBookService) { }

  phoneBooks = [];
  entires = [];
  newEntry = false;
  entryForm: FormGroup;
  currentPhoneBook = null;

  responseMessage: any;
  submitted = false;
  requestServer = false;
  errorMessage;
  ngOnInit(): void {
    this.loadPhoneBooks();
    this.entryForm = this.formBuilder.group({
      name: ['', [Validators.minLength(2), Validators.maxLength(70), Validators.required]],
      phoneNumber: ['', [Validators.minLength(2), Validators.maxLength(70), Validators.required, Validators.pattern(/^[0-9]$/)]],
      phoneBookId: ''
    });
  }
  private loadPhoneBooks(){
    this.phoneBookService.getAll().subscribe(result => {
      this.phoneBooks = result;
    })
  }

  public openPhoneBook(pb){
    this.currentPhoneBook = pb;
    this.phoneBookService.getAllEntries(pb.id).subscribe(result => {
      this.entires = result;
    })
  }

  submit() {
    this.errorMessage = '';
    this.responseMessage = '';
    this.entryForm.value.phoneBookId = this.currentPhoneBook.id;
    this.phoneBookService.create(this.entryForm.value).subscribe(result => {
      this.responseMessage = 'Text kruched and saved to file, please check your file.';
      this.newEntry = false;
      this.entires = [];
      this.currentPhoneBook = null;
      this.loadPhoneBooks();
    }, error => {
      this.errorMessage = error.error;
    })
    this.showMsg();
    this.resetForm();
  }

  get formControls() {
    return this.entryForm.controls;
}

resetForm(){
  this.entryForm.reset();
}

showMsg() : void {
  this.requestServer = true;
  setTimeout(()=> this.requestServer = false,4000);
}


}
