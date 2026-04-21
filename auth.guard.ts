import { inject } from '@angular/core';
import { Router, CanActivateFn } from '@angular/router';
import { TokenService } from '../services/token.service';

export const authGuard: CanActivateFn = (route, state) => {
  const tokenService = inject(TokenService);
  const router = inject(Router);

  // 1. Check if user is logged in
  if (tokenService.isLoggedIn()) {
    return true; // Door opens!
  } else {
    // 2. If not logged in, send them to login page
    router.navigate(['/login']);
    return false; // Door stays locked
  }
};