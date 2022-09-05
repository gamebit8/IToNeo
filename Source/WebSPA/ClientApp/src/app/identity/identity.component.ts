import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { NavFragmentSettings } from '../shared/models/navFragmentSettings.model';
import { IdentityLoginComponent } from './identity-login/identity-login.component';
import { IdentityPasswordRecoveryComponent } from './identity-password-recovery/identity-password-recovery.component';
import { IdentityRegisterComponent } from './identity-register/Identity-register.component';
import { IdentityService } from './identity.service';
import { IdentityAbstract } from './shared/identity-abstract.component';

@Component({
    selector: 'identity',
    templateUrl: './identity.component.html',
    styleUrls: ['./identity.component.css']
})

export class IdentityComponent extends IdentityAbstract implements OnInit{
    private activeNavFragment: NavFragmentSettings
    private navsSettings: NavFragmentSettings[] = new Array<NavFragmentSettings>()


    constructor(protected identityService: IdentityService, private activeLink: ActivatedRoute, private router: Router) {
        super(identityService);
    }

    ngOnInit(): void {
        this.initNavsSettings();
        this.selectDefaultActiveFragment();
        this.subscribeActiveLink();
    }

    private initNavsSettings(): void {
        this.navsSettings.push({ title: this.localization.authorization, fragment: 'authorization', component: IdentityLoginComponent });
        this.navsSettings.push({ title: this.localization.forgotYourPassword, fragment: 'passwordRecovery', component: IdentityPasswordRecoveryComponent, hide: true });
        this.navsSettings.push({ title: this.localization.register, fragment: 'register', component: IdentityRegisterComponent });
    }

    private selectDefaultActiveFragment(): void {
        this.activeNavFragment = this.navsSettings.find(x => x.fragment = 'authorization');
    }

    protected subscribeActiveLink(): void {
        this.activeLink
            .fragment
            .pipe(takeUntil(this.notifier))
            .subscribe(fragment => {
                this.navsSettings.forEach(ns => {
                    if (fragment == ns.fragment) {
                        this.activeNavFragment = ns;
                    }
                })
            });
    }

    private onSelectNav(fragment: string) {
        this.router.navigate(['identity'], { fragment: fragment })
    };
}
