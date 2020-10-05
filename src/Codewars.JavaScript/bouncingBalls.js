function bouncingBall(h,  bounce,  window) {

    let pass = 1;
  
    if (h <= 0 || bounce <= 0 || bounce >= 1 || window >= h) {
      return -1;
    } 
  
    while (h > window){
  
      let currentBounce = h * bounce;
  
      if (currentBounce > window) pass += 2;
  
      h = currentBounce;
    }
  
    return pass;
  
  }