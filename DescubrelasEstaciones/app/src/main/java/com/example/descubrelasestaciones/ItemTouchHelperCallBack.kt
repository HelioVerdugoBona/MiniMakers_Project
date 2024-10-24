package com.example.descubrelasestaciones

import androidx.recyclerview.widget.ItemTouchHelper
import androidx.recyclerview.widget.RecyclerView

class ItemTouchHelperCallBack(private val adapterOrigen: ItemsEstacionesAdapter,
                              private val adapterDestino: MultiEstacionesAdapter):
    ItemTouchHelper.Callback()
{
    override fun getMovementFlags(
        recyclerView: RecyclerView,
        viewHolder: RecyclerView.ViewHolder
    ): Int {

        val dragFlags = ItemTouchHelper.UP or ItemTouchHelper.DOWN // Permitir arrastrar hacia arriba o abajo
        return makeMovementFlags(dragFlags, 0)
    }

    override fun onMove(
        recyclerView: RecyclerView,
        viewHolder: RecyclerView.ViewHolder,
        target: RecyclerView.ViewHolder
    ): Boolean {

        val fromPosition = viewHolder.adapterPosition
        val toPosition = target.adapterPosition

        if (recyclerView.id == R.id.recyclerViewColores) {
            adapterOrigen.moveItem(fromPosition, toPosition)
        } else if (recyclerView.id == R.id.adapterDestino.layout) {
            adapterDestino.moveItem(fromPosition, toPosition)
        }
        return true
    }
    }

    override fun onSwiped(viewHolder: RecyclerView.ViewHolder, direction: Int) {
        TODO("Not yet implemented")
    }

}
