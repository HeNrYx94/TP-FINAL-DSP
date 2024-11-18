using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerMovementTests
{
    [Test]
    public void TestPlayerMovement()
    {
        // Crear jugador y configurar componentes necesarios
        var playerObject = new GameObject();
        var rb = playerObject.AddComponent<Rigidbody2D>();
        var player = playerObject.AddComponent<PlayerController>();
        player.moveSpeed = 5f;

        // Simular entrada de movimiento hacia la derecha
        player.MobileMove(1f);

        // Verificar que la velocidad horizontal es correcta
        Assert.AreEqual(5f, rb.velocity.x, "El jugador no se mueve correctamente hacia la derecha.");
    }
}

public class PlayerJumpTests
{
    [UnityTest]
    public IEnumerator TestPlayerJump()
    {
        // Crear jugador
        var playerObject = new GameObject();
        var rb = playerObject.AddComponent<Rigidbody2D>();
        var player = playerObject.AddComponent<PlayerController>();
        player.jumpForce = 10f;

        // Simular salto
        player.MobileJump();

        // Esperar un frame para que Unity procese la física
        yield return new WaitForFixedUpdate();

        // Verificar que la velocidad vertical del Rigidbody es igual a la fuerza del salto
        Assert.AreEqual(10f, rb.velocity.y, 0.1f, "El jugador no salta con la fuerza esperada.");
    }
}