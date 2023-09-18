N = 10;
n = linspace(1,N,100);
plot(n,ones(size(n)),'DisplayName','O(1)')
hold on; plot(n,1+log(n),'DisplayName','O(log(n))'); hold off
hold on; plot(n,n,'DisplayName','O(n)'); hold off
hold on; plot(n,1+n.*log(n),'DisplayName','O(n log(n))'); hold off
hold on; plot(n,n.^2,'DisplayName','O(n^2)'); hold off
hold on; plot(n,exp(n)+1-exp(1),'DisplayName','O(exp(n))'); hold off
hold on; plot(n,2.^n-1,'DisplayName','O(2^n)'); hold off
hold on; plot(1:N,factorial(1:N),'DisplayName','O(n!)'); hold off
xlim([1,N])
ylim([0,N])
legend