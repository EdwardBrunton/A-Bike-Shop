'use client';

import { Layout, Menu } from 'antd';
import { useRouter } from 'next/navigation';
import { ReactNode } from 'react';
const { Header, Content, Sider } = Layout;

const AppLayout = ({ children }: { children: ReactNode }) => {
	const router = useRouter();

	return (
		<Layout>
			<Header>ABike</Header>
			<Layout>
				<Sider width={200} className='site-layout-background'>
					<Menu
						mode='inline'
						defaultSelectedKeys={['/']}
						style={{ height: '100%', borderRight: 0 }}
						items={[{ label: 'Orders', key: '/' }]}
						onClick={({ key }: { key: string }) => router.push(key)}
					/>
				</Sider>
				<Layout>
					<Content style={{ padding: '24px' }}>{children}</Content>
				</Layout>
			</Layout>
		</Layout>
	);
};

export default AppLayout;
