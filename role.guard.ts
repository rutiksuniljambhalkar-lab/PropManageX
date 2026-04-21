import { inject } from '@angular/core';
import { Router, CanActivateFn } from '@angular/router';
import { TokenService } from '../services/token.service';

export const roleGuard: CanActivateFn = (route, state) => {
  const tokenService = inject(TokenService);
  const router = inject(Router);
  
  // Get the expected roles from the route data
  const expectedRoles = route.data['roles'] as Array<string>;
  const userRole = tokenService.getUser()?.role;

  if (tokenService.isLoggedIn() && expectedRoles.includes(userRole)) {
    return true; // Role matches!
  }

  // If role doesn't match, send to unauthorized page or dashboard
  router.navigate(['/unauthorized']);
  return false;
};