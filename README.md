 Diagnóstico de Enfermedades con IA

Descripción General

Este proyecto es una aplicación de escritorio desarrollada en C# que permite realizar el diagnóstico asistido por IA de enfermedades médicas, registrar pacientes y generar informes automatizados en formato Word. El objetivo es facilitar a profesionales de la salud la gestión del historial clínico y obtener recomendaciones inteligentes gracias a la integración de modelos de lenguaje.

Tecnologías Utilizadas

 1. Lenguaje de Programación y Framework
C#
WinForms para la interfaz de usuario de escritorio

 2.Base de Datos
 SQL Server

3.Modelo de Lenguaje (LLM)
OpenAI API: Se utiliza la API de OpenAI (por ejemplo, GPT-3.5 o GPT-4) para generar recomendaciones de diagnóstico, anamnesis y tratamiento a partir de los datos ingresados por el usuario.  
 Llamadas a la API: La comunicación con el modelo se realiza mediante solicitudes RESTful, enviando antecedentes y síntomas del paciente, y recibiendo como respuesta el análisis y sugerencias de tratamiento.

4.Generación de Informes
OpenXML SDK: Se emplea la librería DocumentFormat.OpenXml para manipular archivos Word y generar informes médicos personalizados, reemplazando marcadores en una plantilla .docx con los datsos del paciente y resultados de la IA.


Cómo lo hicimos

1. Estructura del proyecto
   Carpeta Forms: Contiene todos los formularios de la aplicación (registro, diagnóstico, informes, etc.).
    Carpeta Helpers: Incluye utilidades como WordHelper para la generación de informes Word.
    Carpeta Resources: Almacena la plantilla de informe en formato Word (plantilla_informe.docx).

2. Interfaz y registro
   La aplicación permite registrar pacientes y almacenar sus datos en la base de datos SQLServer.

3. Diagnóstico con IA
    El usuario ingresa síntomas y antecedentes.
    El sistema envía estos datos a la API de OpenAI.
    La respuesta del modelo se almacena y se muestra en pantalla, permitiendo al usuario guardar el diagnóstico.

4. Generación de informes médicos
   A partir de los datos del paciente y la respuesta de la IA, se genera un informe personalizado en Word usando una plantilla.
    El helper WordHelper reemplaza de forma robusta los marcadores en la plantilla para crear el documento final.

5.  consultas
Toda la información se almacena en SQLserver permitiendo consultas, historial y reportes.

