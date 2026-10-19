// sistema de empleados de sofware
//una empresa de desarrollo de sofware gestiona dos tupos de empleados
//con distintas estructuras salariales
//Dev: salario base + bono variable pr cada proyecto completado.
//Gerentes: salario base + bono fijo por gestion directiva 
//calcular el salario total y mnostrar la informacion
//consolidada utilizando herencia y poliorfismo


using System;

public class HelloWorld {

    public class Empleados {
        private string Nombre;
        private int Edad;
        protected decimal Salariobase;

        public Empleados(string nombre, int edad, decimal Salariobase){
            this.Nombre = nombres;
            this.Edad = edad;
            this.Salriobase = salariobase;

        }

        public string nombre {
            get {return nombre;}
            set{
                if(string.IsNullOrwhiteSpace(value))
                    throw new ArgumentException("El nombre no debe estar vacio.");
                nombre = value;
            }
        }


        public int Edad {
            get {return edad;}
            set {
                if (value <18 || value > 65)
                    throw new ArgumentException(""Edad no valida para trabjar!!!.);
                edad = value;
            }
        }

        public virtual decimal Calcularsalario(){
            return salarioBase;
        }

          public virtual string Mostrarinfo(){
        return $"Nombre : {nombre}, Edad : {edad} , Salario total:{CalcularSalario():c}";
              
        }
    
    }

    public class Gerente : Empleado {
        private const decimal BonoGestion = 800.000;

        public Gerente(string nombre, int edad, salarioBase)
            :base(nombre, edad, salarioBase){}

        public override decimal CalcularSalario(){
            return salarioBase + BonoGestion;
    
        }
        public override string MostrarInfo(){
            return base.MostrarInfo() + "| Rol: Gerente";
        }

        
    }
        
    public static void Main(string[] args) {
        Lista<Empleado> empleados = new List<Empleados>{
            new Gerente ("Neider Hernandez", 29, 4.000.000)
        }
        foreach(Empleado e in empleados){
            Console.WriteLine(e.MostrarInfo());
        }
            
    }
  
}
