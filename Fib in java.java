Import java.util.Scanner;
public class Fib
{
static int fib (int n)
{
int x, y;
if (n == 0) return 0;
else if (n == 1) return 1;
else
{
x = fib(n-1);
y = fib (n-2);
return x+y;
}
}
public static void main(String[] args)
{
Scanner input = new Scanner(System.in);
int n, z;
n = input.nextInt();
z = fib (n);
System.out.println("The fiboonacci of "+ n + " is: " + z);
}