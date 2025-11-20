<!-- markdownlint-disable MD033 MD041 -->
<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>
<!-- markdownlint-enable MD033 MD041 -->

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# Ejercicio de aplicación de la guía de diseño *Open/Closed*

Un gimnasio tiene horarios diferenciados según diferentes membresías. Esto es
porque algunos horarios son más demandados que otros y algunos miembros están
dispuestos a pagar más por entrenar en ciertos horarios.

El gimnasio tiene las siguientes membresías:

* Básica

* Premium

* Pase por el día

Las reglas para determinar si un miembro puede ingresar según el día y hora son:

* Lunes a viernes 6am a 10am: Solo los usuarios que tengan membresía premium
  pueden ingresar

* Lunes a viernes 10am a 5pm: Pueden ingresar todos los usuarios con cualquier
  membresía

* Lunes a viernes 5pm a 9pm: Sólo los usuarios con membresía básica o premium
pueden ingresar, los pases por el día no.

* Sábados: Pueden ingresar todos los usuarios con cualquier membresía de 8am a
  8pm.

* Domingos: Cerrado

El tipo enumerado [`Membership`](./src/Library/Membership.cs) representa el tipo de membresía.

La clase [`Gym`](./src/Library/Gym.cs) representa el gimnasio; y el método
`bool CanEnter(Membership, WeekDay, int)` permite determinar si un usuario con
cierta membresía puede ingresar al gimnasio un día de la semana a una hora
determinada.

## Parte 1

Analiza el código del método `bool CanEnter(Membership, WeekDay, int)` de la
clase `Gym` considerando la guía de diseño [Open
Closed](https://github.com/ucudal/PII_Guias/blob/main/OCP.md).

¿El diseño de este código, cumple o no cumple con la guía? ¿Porqué?

Por ejemplo, ¿qué tan fácil es agregar un nuevas reglas para que estudiantes de
la universidad puedan entrenar en ciertos horarios, o que ciertos días el
gimnasio pueda estar reservado para clases especiales?

## Parte 2

En caso de que no lo cumpla, ¿qué modificaciones harías al diseño para que
cumpliera?

> [!TIP]
> El proyecto tiene casos de prueba. Los casos de prueba pasan antes de la
> modificación y deberán pasar también luego.

## Parte 3

Agrega una regla para que los feriados puedan ingresar los usuarios con
membresía premium de 10am a 6pm.

El método de clase `bool IsHoliday(DateTime)` de la clase
[`Calendar`](./src/Library/Calendar.cs) te permite determinar si una fecha dada
es feriado o no.
