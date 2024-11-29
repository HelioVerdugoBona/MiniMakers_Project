package com.example.descubrelasestaciones

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class AvataresAdapter(
    private val context: Context,
    private val avatares: MutableList<Avatar>,
    private val onItemClickListener: (Avatar) -> Unit
) : RecyclerView.Adapter<AvataresAdapter.AvataresViewHolder>() {

    private val layout = R.layout.avatar_item

//  Creamos el ViewHolder para mostrar la vista de cada item
    inner class AvataresViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        private val imagenImageView: ImageView = itemView.findViewById(R.id.ImgAvatar)

        fun bindAvatar(avatar: Avatar) {
            imagenImageView.setImageResource(avatar.imagen)

            // Creamos el evento click de cada item
            itemView.setOnClickListener {
                onItemClickListener(avatar)
            }
        }
    }



//  Añadimos al layout un nuevo item del RecycleView
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AvataresViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)
        return AvataresViewHolder(view)
    }



//  Recogemos la posicion del avatar seleccionado y lo enlazamos a la vista
    override fun onBindViewHolder(holder: AvataresViewHolder, position: Int) {
        val avatar = avatares[position]
        holder.bindAvatar(avatar)
    }


//  Devuelve el tamaño de la lista de avatares
    override fun getItemCount(): Int {
        return avatares.size
    }
}