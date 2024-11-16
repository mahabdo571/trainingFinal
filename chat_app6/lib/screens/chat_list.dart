import 'package:chat_app6/widgets/app_bar_customer.dart';
import 'package:flutter/material.dart';

class ChatList extends StatefulWidget {
  const ChatList({super.key});

  @override
  State<ChatList> createState() => _ChatListState();
}

class _ChatListState extends State<ChatList> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBarCustomer(titleApp: 'Chats'),
      body: Column(
        children: [
          Text('dsdsdsdsdsdsfd'),
          Text('dsdsdsdsdsdsfd'),
          Text('dsdsdsdsdsdsfd'),
          Text('dsdsdsdsdsdsfd'),
        ],
      ),
    );
  }
}
