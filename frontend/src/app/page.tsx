'use client';

import { Button, Typography, message } from 'antd';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { OrderModel } from './componets/order/models/order-model';
import OrderTable from './componets/order/order-table/order-table';
import styles from './page.module.css';

const { Title } = Typography;

export default function OrdersList() {
	const [messageApi, contextHolder] = message.useMessage();
	const [orders, setOrders] = useState<OrderModel[]>([]);
	const router = useRouter();

	useEffect(() => {
		const fetchOrders = async () => {
			try {
				const response = await fetch('http://localhost:5012/orders');
				if (response.ok) {
					const data = (await response.json()) as OrderModel[];
					setOrders(data);
				} else {
					messageApi.open({
						type: 'error',
						content: 'An error occurred while fetching the orders',
					});
				}
			} catch (error) {
				console.error('Error fetching orders:', error);
			}
		};

		fetchOrders();
	}, []);

	return (
		<main className={styles.main}>
			{contextHolder}
			<div className={styles.header}>
				<Title>Orders</Title>
				<Button
					type='primary'
					onClick={() => router.push('/order/create-order')}
				>
					Create Order
				</Button>
			</div>
			<OrderTable orders={orders} />
		</main>
	);
}
