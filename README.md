# Bézier vs. De Casteljau

Aplicación de Windows Forms en C# para dibujar curvas de Bézier y comparar dos formas de calcularlas: los polinomios de Bernstein y el algoritmo de De Casteljau.

## Funciones

- Agregar, mover, modificar y eliminar puntos de control, manteniendo al menos dos.
- Ajustar el número de muestras para ver cómo cambia el trazado de la curva.
- Mover el parámetro `t` entre 0 y 1 para comparar los resultados de ambos métodos y visualizar los niveles de De Casteljau.
- Medir los tiempos de cálculo y exportar los resultados a CSV.
