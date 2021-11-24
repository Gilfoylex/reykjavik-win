<!--会把cs文件生成到obj目录，生成好以后拷贝进项目工程注释掉就可以了-->
	<ItemGroup>
		<!--<Protobuf Include="xray_grpc_define\app\proxyman\command\command.proto" ProtoRoot=".." OutputDir="%(RelativeDir)" CompileOutputs="false" />-->
		<Protobuf Include="xray_grpc_define\app\proxyman\command\command.proto" ProtoRoot="xray_grpc_define" OutputDir="xray_grpc_define" CompileOutputs="false" />
		<Protobuf Include="xray_grpc_define\app\stats\command\command.proto" ProtoRoot="xray_grpc_define" OutputDir="xray_grpc_define" CompileOutputs="false" />
	</ItemGroup>