using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

	public int damage = 10;
	public int reward = 1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Player player = collision.collider.GetComponent<Player>();
		if (player != null)
		{
			if (!Progression.IsGrowing)
				player.TakeDamage(damage); // (enemy 에게) player 는 데미지를 받는다

			base.Die();
		}
	}

	public override void Die()
	{
		Progression.instance.AddScore(reward);
		base.Die();
	}

	public void Remove ()
	{
		base.Die();
	}

}
