import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();
  constructor(private accountService: AccountService, private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe(user => {
      this.router.navigateByUrl('/members');
    }, error => {
      console.log(error);
      this.toastr.error(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
