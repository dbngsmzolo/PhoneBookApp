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
  entries = [];
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
      name: ['', [Validators.minLength(2), Validators.maxLength(100), Validators.required, Validators.pattern(/^[a-zA-ZÀ-ÿšū’][a-zA-ZÀ-ÿšū'’.-\s]*[a-zA-ZÀ-ÿšū.]$/)]],
      phoneNumber: ['', [Validators.minLength(10), Validators.maxLength(10), Validators.required, Validators.pattern(/^(0)(6[0-9]|7([1-4]|(6|8|9))|8[1-4])(\d{7})$/)]],
      phoneBookId: ''
    });
  }
  private loadPhoneBooks(){
    this.phoneBookService.getAll().subscribe(result => {
      this.phoneBooks = result;
    }, error => {
      this.errorMessage = 'An error has accured, please try again';
    });
  }

  public openPhoneBook(pb){
    this.currentPhoneBook = pb;
    this.phoneBookService.getAllEntries(pb.id).subscribe(result => {
      this.entries = result;
    }, error => {
      this.errorMessage = 'An error has accured, please try again';
    });
  }

  submit() {
    this.errorMessage = '';
    this.responseMessage = '';
    this.entryForm.value.phoneBookId = this.currentPhoneBook.id;
    this.phoneBookService.create(this.entryForm.value).subscribe(result => {
      this.responseMessage = 'New Entry Saved.';
      this.newEntry = false;
      this.entries = [];
      this.currentPhoneBook = null;
      this.loadPhoneBooks();
    }, error => {
      this.errorMessage = 'An error has accured, please try again';
    });
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
