import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { faSpinner, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { finalize, first, takeUntil } from 'rxjs/operators';
import { ResponseStatus } from '../../shared/enums/ResponseStatus';
import { IdentityAbstract } from '../shared/identity-abstract.component';
import { IdentityConfirmEmailService } from './identity-confirm-email.service';

@Component({
    selector: 'identity-confirm-email',
    templateUrl: './identity-confirm-email.component.html',
    styleUrls: ['./identity-confirm-email.component.css']
})

export class IdentityConfirmEmailComponent extends IdentityAbstract implements OnInit{
    private email: string
    private token: string
    private emailConfirmed: boolean
    private emailConfirmationError: boolean
    private faSpinner: IconDefinition = faSpinner;

    constructor(protected identityConfirmEmailService: IdentityConfirmEmailService, private activeLink: ActivatedRoute) {
        super(identityConfirmEmailService)
    }

    ngOnInit(): void {
        this.subscribeActivatedRoute();
    }

    private subscribeActivatedRoute(): void {
        this.activeLink
            .queryParams
            .pipe(takeUntil(this.notifier))
            .subscribe(query => {
                this.email = query['email'];
                this.token = query['token'];

                if (this.email && this.token)
                    this.confirmEmail();
            })
    }

    private confirmEmail(): void {
        this.isLoading = true;
        this.identityConfirmEmailService
            .confirmEmail(this.email, this.token)
            .pipe(
                takeUntil(this.notifier),
                finalize(() => this.isLoading = false)
            )
            .subscribe(
                res => {
                    if (res.status == ResponseStatus.Ok) {
                        this.emailConfirmationError = false;
                        this.emailConfirmed = true;
                    }
                },
                err => {
                    this.emailConfirmed = false;
                    this.emailConfirmationError = true;
                }
            );
    }
}
