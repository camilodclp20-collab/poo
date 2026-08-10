class persona:
    def __init__(self, nombre, edad):
        self.nombre = nombre
        self.edad = edad


    def saludar(self):
         return f"hola, soy {self.nombre} y tengo {self.edad} años"

p = persona("Deymar", 18)
print(p.saludar())   
